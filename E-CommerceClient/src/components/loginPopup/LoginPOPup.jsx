import React, { useState } from 'react'
import "./loginpop.css"
import { assets } from '../../assets/frontendassets/frontend_assets/assets'
import { useForm } from 'react-hook-form'
import { login, signUp } from '../../service/authService/authService'
const LoginPOPup = ({setShowLogin}) => {
  const [currentState,setCurrentState]=useState("sign-up")
   const {register,handleSubmit,formState:{errors}}=useForm(); 
  
    const submit = async (model) =>{
      console.log(currentState)
      if(currentState === "login"){
       var response= await login(model);
      if(response.isSuccess){
        localStorage.setItem("token",response.value.token)
        console.log(response.value)
      }
    }
      else{
        const response = await signUp(model)
        if(response.isSuccess){
          console.log(response.value)
          alert(response.message)
        }
      }
      
     
    }
  return (
    <div className='login-popup'>
      <form  className='login-popup-container' noValidate onSubmit={handleSubmit(submit)}>
        <div className='login-popup-title'>
          <h2>{currentState}</h2>
          <img onClick={()=>setShowLogin(false)} src={assets.cross_icon} alt="" />
        </div>
        <div className='login-popup-input'>
          {
            currentState==="sign-up"&&<input type="text" placeholder='enter your name' required {...register("name")} />
          }
          
          <input type="email" placeholder='your email'  required {...register("email")}/>
          <input type="password" placeholder='your password'  required {...register("password")}/>
        </div>
        <button>{currentState==="sign-up"?"Create account":'login'}</button>
        <div className='login-popup-condition'>
          <input type="checkbox" required/>
          <p>By continuing, i agree to the terms of use & privacy policy.</p>
        </div>
        {
          currentState==="sign-up"?<p>Already have an account?<span onClick={()=>setCurrentState("login")}>login here</span></p>:
          <p>Create a new account? <span onClick={()=>setCurrentState("sign-up")}>click here</span></p>
        }
        
        
      </form>
    </div>
  )
}

export default LoginPOPup
