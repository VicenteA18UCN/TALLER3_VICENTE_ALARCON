import axios, { AxiosError, AxiosResponse } from "axios";
import { UserUpdate } from "../models/UserUpdate";
import { ChangePwd } from "../models/ChangePwd";
import AsyncStorage from "@react-native-async-storage/async-storage";

/**
 * Función para pausar la ejecución por un breve periodo de tiempo.
 * @function
 * @returns {Promise<void>} - Promesa que se resuelve después de una breve pausa.
 */
const sleep = () => new Promise((resolve) => setTimeout(resolve, 0));

/**
 * Dirección IP local para la conexión a la API.
 * @constant {string}
 */
const IP_V4 = process.env.EXPO_PUBLIC_IP_V4
axios.defaults.baseURL = `http://${IP_V4}:5000/api`;
axios.defaults.withCredentials = true;

/**
 * Función que extrae el cuerpo de la respuesta Axios.
 * @function
 * @param {AxiosResponse} response - Respuesta Axios.
 * @returns {*} - Cuerpo de la respuesta.
 */
const responseBody = (response: AxiosResponse) => response.data;

/**
 * Función que agrega el token de autenticación a la configuración de la solicitud.
 * @function
 * @async
 * @param {object} config - Configuración de la solicitud Axios.
 * @returns {Promise<object>} - Configuración de la solicitud con el token agregado.
 */
const addTokenToRequest = async (config: any) => {
  const token = await AsyncStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
};

axios.interceptors.request.use(addTokenToRequest);

axios.interceptors.response.use(
  async (response) => {
    await sleep();
    return response;
  },
  (error: AxiosError) => {
    const { data, status } = error.response as AxiosResponse;
    switch (status) {
      case 400:
        break;
      case 401:
        break;
      case 500:
        break;
      default:
        break;
    }
    return Promise.reject(error.response);
  }
);

/**
 * Objeto que contiene funciones de solicitud HTTP comunes.
 * @namespace
 */
const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  del: (url: string) => axios.delete(url).then(responseBody),
};

/**
 * Objeto que contiene funciones de autenticación.
 * @namespace
 */
const Auth = {
  login: (email: string, password: string) =>
    requests.post("/auth/login", { email, password }),
  register: (fullname: string, email: string, birthday: number, rut: string) =>
    requests.post("/auth/register", { fullname, email, birthday, rut }),
  password: (email: string, newPassword: ChangePwd) =>
    requests.put(`/auth/update-password/${email}`, newPassword),
};

/**
 * Objeto que contiene funciones para interactuar con repositorios.
 * @namespace
 */
const Repository = {
  list: () => requests.get("/repositories"),
};

/**
 * Objeto que contiene funciones para interactuar con commits.
 * @namespace
 */
const Commit = {
  list: (repositoryName: string) =>
    requests.get(`/repositories/commits/${repositoryName}`),
};

/**
 * Objeto que contiene funciones para interactuar con usuarios.
 * @namespace
 */
const User = {
  info: (email: string) => requests.get(`/users/${email}`),
  update: (rut: string, userUpdate: UserUpdate) =>
    requests.put(`/users/${rut}`, userUpdate),
};

/**
 * Objeto que agrupa los diferentes módulos de funciones.
 * @namespace
 * @property {object} Auth - Funciones de autenticación.
 * @property {object} Repository - Funciones de repositorio.
 * @property {object} Commit - Funciones de commit.
 * @property {object} User - Funciones de usuario.
 */
const agent = { Auth, Repository, Commit, User };

export default agent;
