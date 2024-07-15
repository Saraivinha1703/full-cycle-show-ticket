FROM node:20-slim

WORKDIR /home/next/app
COPY . .

RUN yarn install

EXPOSE 3000

CMD yarn build && yarn start