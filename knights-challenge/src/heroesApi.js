import axios from 'axios';

const baseURL = 'https://localhost:44318/api/challanger/knight'; // Substitua pelo URL da sua API

export default {
    getAll() {
        return axios.get(baseURL);
    },
    get(id) {
        return axios.get(`${baseURL}/${id}`);
    },
    create(data) {
        return axios.post(baseURL, data);
    },
    update(id, data) {
        return axios.put(`${baseURL}/${id}`, data);
    },
    delete(id) {
        return axios.delete(`${baseURL}/${id}`);
    }
};