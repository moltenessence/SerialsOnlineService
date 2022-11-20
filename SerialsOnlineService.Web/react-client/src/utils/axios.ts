import axios from 'axios';
import { API_URL } from '../Common/Constants';

const axiosInstance = axios.create({
  baseURL: API_URL
});

export { axiosInstance };