import apiClient from "../../constents/lib/axios"

export const categoryAdd = async (model)=>{
    return (await apiClient.post("categories",model))?.data;
}

export const getCategories = async ()=>{
    return (await apiClient.get("categories"))?.data;
}

export const deleteCategory = async (id)=>{
    console.log(id)
    return (await apiClient.delete(`categories/${id}`))?.data;
}