import axios, {AxiosError, AxiosResponse} from 'axios';

axios.defaults.baseURL = 'http://192.168.0.13:5000/api';

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del: (url: string) => axios.delete(url).then(responseBody)
};

const Auth = {
    login: (email: string, password: string) => requests.post('/auth/login', {email, password}),
    register: (fullname:string, email:string, birthday:number , rut:string) => requests.post('/auth/register', {fullname, email, birthday, rut})
};

const Repository = {
    list: () => requests.get('/repositories'),
};

const Commit = {
    list: (repositoryName: string) => requests.get(`/repositories/commits/${repositoryName}`)
};

const agent = { Auth, Repository, Commit };

export default agent;