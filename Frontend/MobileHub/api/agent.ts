import axios, { AxiosError, AxiosResponse } from "axios";
import { UserUpdate } from "../models/UserUpdate";
import { ChangePwd } from "../models/ChangePwd";
import AsyncStorage from "@react-native-async-storage/async-storage";

const sleep = () => new Promise((resolve) => setTimeout(resolve, 1000));

axios.defaults.baseURL = "http://192.168.0.10:5000/api";
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

const addTokenToRequest = async (config: any) => {
  const token = await AsyncStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
};

axios.interceptors.request.use(addTokenToRequest);

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  del: (url: string) => axios.delete(url).then(responseBody),
};

const Auth = {
  login: (email: string, password: string) =>
    requests.post("/auth/login", { email, password }),
  register: (fullname: string, email: string, birthday: number, rut: string) =>
    requests.post("/auth/register", { fullname, email, birthday, rut }),
  password: (email: string, newPassword: ChangePwd) =>
    requests.put(`/auth/update-password/${email}`, newPassword),
};

const Repository = {
  list: () => requests.get("/repositories"),
};

const Commit = {
  list: (repositoryName: string) =>
    requests.get(`/repositories/commits/${repositoryName}`),
};

const User = {
  info: (email: string) => requests.get(`/users/${email}`),
  update: (rut: string, userUpdate: UserUpdate) =>
    requests.put(`/users/${rut}`, userUpdate),
};

const agent = { Auth, Repository, Commit, User };

export default agent;
