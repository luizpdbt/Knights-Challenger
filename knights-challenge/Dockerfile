# Use a imagem oficial do Node.js
FROM node:lts-alpine

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia o package.json e o package-lock.json para o diretório de trabalho
COPY package*.json ./

# Instala as dependências
RUN npm install

# Copia todos os arquivos do projeto para o diretório de trabalho
COPY . .

# Expor a porta 3000 (porta padrão do servidor de desenvolvimento do Vite)
EXPOSE 5173

# Comando para iniciar a aplicação em modo de desenvolvimento
CMD ["npm", "run", "dev"]
