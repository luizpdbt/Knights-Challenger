<script setup lang="ts">
</script>

<template>
<div id="cadastroHerois">
    <form>
      <label for="name">Nome:</label>
      <input type="text" id="name"  required><br>

      <label for="nickname">Apelido:</label>
      <input type="text" id="nickname"  required><br>

      <label for="birthday">Data de Nascimento:</label>
      <input type="date" id="birthday"  required><br>

      <label for="strength">Força:</label>
      <input type="number" id="strength" required><br>

      <!-- Adicione os campos restantes conforme necessário -->
      <button type="submit">Adicionar Herói</button>
  </form>
</div>
</template>


<style>
        /* Estilos do modal */
        .modal-mask {
            position: fixed;
            z-index: 9998;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .modal-wrapper {
            max-width: 600px;
            max-height: 80%;
            overflow: auto;
        }

        .modal-container {
            background-color: #fff;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        .modal-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
        }

        .modal-close-button {
            border: none;
            background-color: transparent;
            cursor: pointer;
            font-size: 20px;
        }
    </style>