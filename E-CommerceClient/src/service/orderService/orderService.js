import apiClient from "../../constents/lib/axios"

export const orderPlace = async (model)=>{
    return (await apiClient.post("orders",model))?.data;
}

export const getOrderByStatus = async ()=>{
    return (await apiClient.get("orders"))?.data;
}

export const getCount = async ()=>{
    return (await apiClient.get("orders/count"))?.data;
}


export const updateOrderStatus = async (model)=>{
    console.log(model)
  return (await apiClient.put("orders",model))?.data;
}