FROM mcr.microsoft.com/dotnet/sdk:8.0
ENV ASPNETCORE_HTTP_PORTS=5000
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000

WORKDIR /home/dotnet/app
COPY . .

USER root

RUN dotnet restore
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

CMD tail -f /dev/null