# TALLER 3 - INTRODUCCIÓN AL DESARROLLO WEB/MÓVIL

## Realizado por Vicente Alarcón

# Introducción

Para la correcta ejecución del proyecto, se debe tener instalado los siguientes programas:

- [Node.js (v18.18.2)](https://nodejs.org/download/release/v18.18.2/node-v18.18.2-x64.msi)
- [Dotnet SDK v8.0.1](https://dotnet.microsoft.com/es-es/download/dotnet/thank-you/sdk-8.0.100-windows-x64-installer)
- [Git v2.43.0](https://git-scm.com/downloads)
- [Android Studio](https://developer.android.com/studio) o [Expo Go](https://expo.dev/client) en tu dispositivo móvil
- Puerto 5000 disponible

# Instalación del proyecto

Abrir una consola de comando, y colocar lo siguiente:

```bash
 dotnet tool install --global dotnet-ef
```

Una vez instalado, clonar el repositorio en la carpeta deseada con el siguiente comando:

```bash
git clone https://github.com/VicenteA18UCN/TALLER3_VICENTE_ALARCON.git
```

Luego, ingresar a la carpeta del proyecto:

```bash
cd TALLER3_VICENTE_ALARCON
cd Backend
cd MobileHub
```

Dentro de la carpeta MobileHub, se debe copiar el archivo _.env.example_ y renombrarlo a _.env_, de la siguiente forma:

```bash
cp .env.example .env
```

Luego, modificar los siguientes parametros:

```bash
GITHUB_TOKEN= # Token de GitHub
SECRET_KEY= # Llave secreta para JWT
```

Una vez dentro de la carpeta, ejecutar los siguientes comandos, para la instalación de las dependencias, la creación de la base de datos y la ejecución del proyecto:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Luego abrir otra consola de comando en la carpeta donde esta alojada el proyecto, y colocar lo siguiente:

```bash
cd TALLER3_VICENTE_ALARCON
cd Frontend
cd MobileHub
```

Dentro de la carpeta MobileHub, se debe copiar el archivo _.env.example_ y renombrarlo a _.env_, de la siguiente forma:

```bash
cp .env.example .env
```

Luego, modificar los siguientes parametros:

```bash
IP_V4= # IP V4 de tu computador
```

Para obtener la IP V4 de tu computador, se debe abrir una consola de comando (en Windows) y colocar lo siguiente:

```bash
ipconfig
```

Una vez dentro de la carpeta, ejecutar los siguientes comandos, para la instalación de las dependencias y la ejecución del proyecto:

```bash
npm install
npx expo start
```

## Uso

Para el uso de la aplicación, se debe tener en cuenta que se debe tener instalado el emulador de Android Studio, o tener instalado Expo Go en tu dispositivo móvil.

En caso de utilizar Android Studio, se debe apretar la tecla "a" en la consola de comando donde se ejecutó el comando "npx expo start", y se abrirá el emulador de Android Studio.

En caso de utilizar Expo Go, se debe escanear el código QR que aparece en la consola de comando donde se ejecutó el comando "npx expo start", y se abrirá la aplicación en tu dispositivo móvil.
