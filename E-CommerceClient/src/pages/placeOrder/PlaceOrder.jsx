import React, { useContext } from 'react'
import "./placeorder.css"
import { StoreContext } from '../../context/StoreContext'
import { ToastContainer, toast } from 'react-toastify';
import {useForm} from "react-hook-form"
import { orderPlace } from '../../service/orderService/orderService';

const PlaceOrder = () => {
let {register,handleSubmit}=useForm()

const Deliver= async (model)=>{
   const response = await orderPlace(model)
   if(response.isSuccess){
  toast.success(response.message)
   }

  }


const {getTotalCartAmount}=useContext(StoreContext)
  return (
    <>
    <form className='place-order' onSubmit={handleSubmit(Deliver)}>
      <div className='place-order-left'>
        <p className='title'>Delivery Information</p>
        <div className="multi-fields">
          <input type="text" placeholder='First Name'{...register("name",{
            required:{
              message:"name is required"
            }
          })}/>
          <input type="text"  placeholder='Last Name'/>
        </div>
        <input type="email" placeholder='email address'{...register("email",{
          required:{
            message:"email is required"
          }
        })}/>
        <input type="text" placeholder='Street'{...register("street",{required:{message:"street is required"}})}/>
        <div className="multi-fields">
          <input type="text" placeholder='City'{...register("city",{required:{message:"this field is required"}})}/>
          <input type="text"  placeholder='State'{...register("state",{required:{message:"this field is required"}})}/>
        </div>
        <div className="multi-fields">
          <input type="text" placeholder='ZipCode'{...register("zip code",{required:{message:"this field is required"}})}/>
          <input type="text"  placeholder='Country'{...register("country",{required:{message:"this field is required"}})}/>
        </div>
        <input type="text" placeholder='phone'{...register("contactNo",{required:{message:"this field is required"}})} />
      </div>


      <div className='place-order-right'>
      <div className='cart-total'>
          <h2>Cart total</h2>
          <div>
            <div className="cart-total-details">
              <p>Sub Total</p>
              <p>${getTotalCartAmount()}</p>
            </div>
            <hr />
            <div className="cart-total-details">
              <p>Delivery fee</p>
              <p>${getTotalCartAmount()===0?0:2}</p>
            </div>
            <hr />
            <div className="cart-total-details">
              <b>Total</b>
              <b>${getTotalCartAmount()===0?0:getTotalCartAmount()+2}</b>
            </div>
          </div>
          <button >Proceed to Payment</button>
          <button >Cash On Delivery</button>
        </div>
      </div>
      
    </form>
    <ToastContainer/>
    </>
  )
}

export default PlaceOrder
