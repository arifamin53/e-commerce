import apiClient from "../../constents/lib/axios"

export const addCartItem = async (model) =>{
   
    return (await apiClient.post("carts",{
        item:model
    }))?.data;
}