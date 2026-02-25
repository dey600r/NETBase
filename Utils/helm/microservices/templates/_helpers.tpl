{{/*
Expand the name of the chart.
*/}}
{{- define "microservice.name" -}}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "microservice.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Common labels
*/}}
{{- define "microservice.labels" -}}
helm.sh/chart: {{ include "microservice.chart" . }}
{{ include "microservice.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{- define "microservice.labels.runtime" -}}
app.openshift.io/runtime: {{ .Values.deployment.labels.runtime }}
{{- end }}

{{- define "microservice.annotations.connectsTo" -}}
app.openshift.io/connects-to: '{{ .Values.deployment.annotations.connectsTo | toJson }}'
{{- end}}

{{/*
Selector labels
*/}}
{{- define "microservice.selectorLabels" -}}
app: {{ .Release.Namespace }}
app.kubernetes.io/part-of: {{ .Release.Namespace }}
app.kubernetes.io/name: {{ include "microservice.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

