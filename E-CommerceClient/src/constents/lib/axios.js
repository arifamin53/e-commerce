import axios from "axios";
import { API_URL } from "../appUrls";
import { getAuthToken } from "../../serverActions";

export const apiClient = axios.create({
        baseURL:API_URL
});

apiClient.interceptors.request.use(async config=>{
  
       const token= localStorage.getItem("token")
        if(token){
            config.headers['Authorization'] = `Bearer ${token}`;
        }
    return config;
}, (error) => {
   console.error(error);
  return Promise.reject(error);
});


apiClient.interceptors.response.use(
       function (response) {
       return  response;
      },

    function  (error) {
       if (error.response && error.response.status === 400) {
         // Handle unauthorized errors, e.g., redirect to login.
          toast.error('Bad Request: ' + (error.response.data.problemDetails?.title || 'Invalid request'))
        //  Router.push('/login');
        }
        else if (error.response && error.response.status === 401) {
          // Handle unauthorized errors, e.g., redirect to login.
//         // Call a function to refresh the token
//         const newToken = await refreshAuthToken();
//         error.config.headers['Authorization'] = `Bearer ${newToken}`;
//         // Retry the original request with the new token
//         return axios(error.config);
                toast.error('Unauthorized: ' + (error.response.data.problemDetails?.title || 'You are not authorized to access this resource. Please login again.'))
           
             window.location.href = '/login';
        }
         else if (error.response && error.response.status === 403) {
          // Handle unauthorized errors, e.g., redirect to login.
          console.error("Axios error ",error.response);
          console.error("Axios error ",error.response.data);
          console.error("Axios error ",error.response.data.problemDetails);
          toast.error('Forbidden: ' + (error.response.data.problemDetails?.title || 'You do not have permission to access this resource.'))
          // Router.push('/login');
        }
        else if (error.response && error.response.status === 404) {
          // Handle unauthorized errors, e.g., redirect to login.
          toast.error('Not Found: ' + (error.response.data.problemDetails?.title || 'The requested resource was not found.'))
          // Router.push('/login');
        }
       
        else if (error.response && error.response.status >= 400 && error.response.status < 500) {
          // Handle client errors.
          toast.error('Client Error: ' + (error.response.data.problemDetails?.title || 'An error occurred with your request. Please check and try again.'))
        }
        else if (error.response && error.response.status >= 500) {
          // Handle server errors.
          toast.error('Server Error: ' + (error.response.data.problemDetails?.title || 'An error occurred on the server. Please try again later.'))
        }
        return Promise.reject(error);
      }
    );

export default apiClient