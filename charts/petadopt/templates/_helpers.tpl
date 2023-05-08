{{/*
Return the proper petdomain image name
*/}}
{{- define "petdomain.image" -}}
{{ include "common.images.image" (dict "imageRoot" .Values.petdomain.image "global" .Values.global) }}
{{- end -}}

{{/*
Return the proper Docker Image Registry Secret Names
*/}}
{{- define "petdomain.imagePullSecrets" -}}
{{- include "common.images.pullSecrets" (dict "images" (list .Values.petdomain.image) "global" .Values.global) -}}
{{- end -}}

{{/*
Create the name of the service account to use
*/}}
{{- define "petdomain.serviceAccountName" -}}
{{- if .Values.petdomain.serviceAccount.create -}}
    {{ default (include "common.names.fullname" .) .Values.petdomain.serviceAccount.name }}
{{- else -}}
    {{ default "default" .Values.petdomain.serviceAccount.name }}
{{- end -}}
{{- end -}}
