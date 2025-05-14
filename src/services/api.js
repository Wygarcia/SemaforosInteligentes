import axios from 'axios';

const api = axios.create({
    baseURL: 'https://www.semaforosinteligentes.somee.com/api' // Usa el puerto de tu backend ASP.NET
});

export const getHechos = () => api.get('/HechoTrafico');
export const getSemaforos = () => api.get('/DimSemaforo');
// Agrega más según necesites
