import apiClient from "../../constents/lib/axios"

export const orderPlace = async (model)=>{
    return (await apiClient.post("orders",model))?.data;
}