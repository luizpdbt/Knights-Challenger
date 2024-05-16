<script setup lang="ts">
import WelcomeItem from './WelcomeItem.vue'
import ModalCadastro from './ModalCadastro.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import ToolingIcon from './icons/IconTooling.vue'
</script>

<template>
  <WelcomeItem>
    <template #icon>
      <DocumentationIcon />
    </template>
    <template #heading>
      <a href="https://vuejs.org/" target="_blank" rel="noopener">Cadastrar Guerreiro</a>
    </template>
  </WelcomeItem>

  <WelcomeItem>
    <template #icon>
      <ToolingIcon />
    </template>
    <template #heading>
      <a href="https://vuejs.org/" target="_blank" rel="noopener">Listar Guerreiros</a>
    </template>
    <br />
  </WelcomeItem>

  <ModalCadastro>
    <template>
      <h3>Cadastro Heroi</h3>
    </template>
  </ModalCadastro>
  
</template>




