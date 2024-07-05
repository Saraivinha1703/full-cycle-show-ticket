FROM mcr.microsoft.com/dotnet/sdk:8.0
ENV ASPNETCORE_HTTP_PORTS=5000;5001
ENV ASPNETCORE_URLS=http://*:5000;http://*:5001;

EXPOSE 5000
EXPOSE 5001

WORKDIR /home/dotnet/app
COPY . .

USER root

RUN dotnet restore
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet run

CMD tail -f /dev/null