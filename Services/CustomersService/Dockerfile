#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
#WORKDIR /src
#COPY ["Services/CustomersService/CustomersService.csproj", "Services/CustomersService/"]
#RUN dotnet restore "Services/CustomersService/CustomersService.csproj"
#COPY . .
#WORKDIR "/src/Services/CustomersService"
#RUN dotnet build "CustomersService.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "CustomersService.csproj" -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "CustomersService.dll"]