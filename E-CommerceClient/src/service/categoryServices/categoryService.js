import apiClient from "../../constents/lib/axios"

export const categoryAdd = async (model)=>{
    return (await apiClient.post("categories",model))?.data;
}

export const getCategories = async ()=>{
    return (await apiClient.get("categories"))?.data;
}