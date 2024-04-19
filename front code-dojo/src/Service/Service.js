import axios from 'axios';

// const porta = '4466';

// const ipSenai = '172.16.39.109';

const apiUrlLocal = `http://172.16.39.109:5068/api`

const api = axios.create({
    baseURL: apiUrlLocal
});

export default api;
