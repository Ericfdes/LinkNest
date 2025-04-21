import axios from "axios";
import { AxiosError } from "axios";
//const BASE_API_URL = 'https://localhost:7005/'
//const BASE_API_URL = 'http://localhost:5250/'
const BASE_API_URL = import.meta.env.VITE_API_URL; //docker url


const apiClient = axios.create({
  baseURL: BASE_API_URL, 
  headers: {
    "Content-Type": "application/json",
  },
  withCredentials: true, // If the backend requires cookies/session authentication
});

export const  handleApiError =  (error : unknown) =>{
  if (error instanceof AxiosError) {
    console.error("API Error:", error.response?.data || error.message);
  } else {
    console.error("Unexpected Error:", error);
  }
}

//res interceptors
// req interceptors
export default apiClient;