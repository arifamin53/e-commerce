import apiClient from "../../constents/lib/axios"

export  const  login =  async (model) =>{
return (await apiClient.post("user/login",model))?.data;
}

export const signUp = async (model) =>{
return (await apiClient.post("user/signup",model))?.data;
}