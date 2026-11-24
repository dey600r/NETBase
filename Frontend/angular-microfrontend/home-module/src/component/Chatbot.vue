<script setup>
import { ref, nextTick } from 'vue'

const API_BASE = 'https://localhost:44306/api/Chatbot'
const N8N_ENDPOINTS = {
  'search-explanation': 'http://127.0.0.1:5678/webhook-test/857d82ed-6032-4582-a95c-ed003c52d145',
  vectorize: 'http://127.0.0.1:5678/webhook-test/7aaf6446-3990-45df-aa3a-30c2ee3e819f'
}
const sessionId = Math.floor(Math.random() * 1_000_000_000)

const input = ref('')
const backend = ref('local')
const model = ref('ollama')
const messages = ref([])
const loading = ref(false)
const outputRef = ref(null)

async function addMessage(author, text) {
  messages.value.push({ author, text })
  await nextTick()
  if (outputRef.value) outputRef.value.scrollTop = outputRef.value.scrollHeight
}

function formatResponse(raw) {
  try {
    let data = JSON.parse(raw)
    if (Array.isArray(data) && data.length === 1) data = data[0]
    if (typeof data === 'string') return data
    // n8n webhooks usually wrap the answer in one of these fields
    const text = data?.output ?? data?.text ?? data?.response ?? data?.message
    return typeof text === 'string' ? text : JSON.stringify(data, null, 2)
  } catch {
    return raw
  }
}

function callLocal(endpoint, text) {
  const params = new URLSearchParams({ plainText: text })
  if (endpoint === 'search-explanation') params.set('type', model.value)
  return fetch(`${API_BASE}/${endpoint}?${params}`, {
    method: 'POST',
    headers: { accept: '*/*' },
    body: ''
  })
}

function callN8n(endpoint, text) {
  const body = endpoint === 'search-explanation' ? { text, sessionId } : { text }
  return fetch(N8N_ENDPOINTS[endpoint], {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(body)
  })
}

async function callApi(endpoint, text) {
  const response = backend.value === 'n8n'
    ? await callN8n(endpoint, text)
    : await callLocal(endpoint, text)
  if (!response.ok) throw new Error(`HTTP ${response.status}`)
  return formatResponse(await response.text())
}

async function send(endpoint) {
  const text = input.value.trim()
  if (!text || loading.value) return
  loading.value = true
  await addMessage('user', text)
  input.value = ''
  try {
    const result = await callApi(endpoint, text)
    await addMessage(
      'bot',
      endpoint === 'vectorize'
        ? 'Se han guardado en el contexto los datos correctamente'
        : result
    )
  } catch (error) {
    await addMessage('error', `Error: ${error.message}`)
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <div class="chatbot">
    <div ref="outputRef" class="chat-output">
      <div v-for="(msg, index) in messages" :key="index" :class="['message', msg.author]">
        {{ msg.text }}
      </div>
      <div v-if="loading" class="message bot">...</div>
    </div>

    <div class="chat-input">
      <input
        v-model="input"
        type="text"
        placeholder="Escribe tu mensaje..."
        :disabled="loading"
        @keyup.enter="send('search-explanation')"
      />
      <select v-model="backend" :disabled="loading" aria-label="API">
        <option value="local">local</option>
        <option value="n8n">n8n</option>
      </select>
      <select v-if="backend === 'local'" v-model="model" :disabled="loading" aria-label="Modelo">
        <option value="gemini">Gemini</option>
        <option value="ollama">Ollama</option>
      </select>
      <button :disabled="loading || !input.trim()" @click="send('vectorize')">Guardar en contexto</button>
      <button :disabled="loading || !input.trim()" @click="send('search-explanation')">Consultar</button>
    </div>
  </div>
</template>

<style scoped>
.chatbot {
  display: flex;
  flex-direction: column;
  height: 70vh;
  width: 100%;
  border: 1px solid #ccc;
  border-radius: 8px;
  overflow: hidden;
}

.chat-output {
  flex: 1;
  overflow-y: auto;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.message {
  max-width: 80%;
  padding: 0.5rem 0.75rem;
  border-radius: 8px;
  white-space: pre-wrap;
  word-break: break-word;
}

.message.user {
  align-self: flex-end;
  background: #42b883;
  color: #fff;
}

.message.bot {
  align-self: flex-start;
  background: #f0f0f0;
  color: #222;
}

.message.error {
  align-self: flex-start;
  background: #fdecea;
  color: #b00020;
}

.chat-input {
  display: flex;
  flex-wrap: wrap;
  gap: 0.5rem;
  padding: 0.75rem;
  border-top: 1px solid #ccc;
}

.chat-input input {
  flex: 1;
  min-width: 10rem;
  padding: 0.5rem;
}

.chat-input select {
  padding: 0.5rem;
}

.chat-input button {
  padding: 0.5rem 1rem;
  cursor: pointer;
}

.chat-input button:disabled {
  cursor: not-allowed;
  opacity: 0.6;
}
</style>
