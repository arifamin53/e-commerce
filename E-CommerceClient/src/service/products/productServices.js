import apiClient from "../../constents/lib/axios"

 export const getProducts = async () =>{
    return (await apiClient.get("products/all") )?.data;
 }