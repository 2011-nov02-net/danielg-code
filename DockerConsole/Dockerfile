# Step 1- choose image with dependiecnies to copy in 
FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app
# Step 2 - copy that thing in
COPY . ./
# i can put it where i want so ill pick a place with a nice short absolute path.


RUN dotnet publish -o publish
# Step 3 - configure it with the command it will use to start containers
#CMD dotnet /app/DockerConsole.dll

CMD dotnet publish/DockerConsole.dll
# how to use this docker file?
# 1) docker publish -o publish
# 2) docker build -t docker-console .
# 3) docker run docker-console