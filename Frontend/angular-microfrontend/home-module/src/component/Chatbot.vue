<script setup>
import { ref, nextTick } from 'vue'

const API_BASE = 'https://localhost:44306/api/Chatbot'

const input = ref('')
const messages = ref([])
const loading = ref(false)
const outputRef = ref(null)

async function addMessage(author, text) {
  messages.value.push({ author, text })
  await nextTick()
  if (outputRef.value) outputRef.value.scrollTop = outputRef.value.scrollHeight
}

async function callApi(endpoint, text) {
  const response = await fetch(
    `${API_BASE}/${endpoint}?plainText=${encodeURIComponent(text)}`,
    { method: 'POST', headers: { accept: '*/*' }, body: '' }
  )
  if (!response.ok) throw new Error(`HTTP ${response.status}`)
  const raw = await response.text()
  try {
    const data = JSON.parse(raw)
    return typeof data === 'string' ? data : JSON.stringify(data, null, 2)
  } catch {
    return raw
  }
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
  gap: 0.5rem;
  padding: 0.75rem;
  border-top: 1px solid #ccc;
}

.chat-input input {
  flex: 1;
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
