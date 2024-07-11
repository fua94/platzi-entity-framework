FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine
WORKDIR /home
# RUN pip3 install debugpy
EXPOSE 80
CMD ["sleep", "infinity"]