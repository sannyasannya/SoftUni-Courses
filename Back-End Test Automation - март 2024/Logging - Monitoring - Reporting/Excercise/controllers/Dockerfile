FROM node:latest

WORKDIR /home/node/app

COPY package*.json ./

RUN npm ci

COPY . .

EXPOSE 8090

CMD ["npm", "start"]