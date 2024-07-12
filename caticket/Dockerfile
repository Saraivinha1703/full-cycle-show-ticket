FROM node:20-slim

WORKDIR /home/next/app
COPY . .

RUN yarn

RUN yarn build

RUN yarn start