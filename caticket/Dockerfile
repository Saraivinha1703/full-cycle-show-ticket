FROM node:20-slim

USER root

RUN mkdir -p /usr/src/app
WORKDIR /home/next/app

COPY package.json /home/next/app
RUN yarn install

COPY . /home/next/app

EXPOSE 3000
