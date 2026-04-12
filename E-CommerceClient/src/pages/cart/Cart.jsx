import React, { useContext, useEffect, useState } from 'react'
import "./cart.css"
import { StoreContext } from '../../context/StoreContext'
import { useNavigate } from 'react-router-dom'
import { Base_url } from '../../constents/appUrls'
import { CgLaptop } from 'react-icons/cg'
import { addCartItem } from '../../service/cart/cartServices'
const Cart = ({setShowLogin}) => {
  const navigate=useNavigate()
  const {cartItem,food_list,removeFromCart,getTotalCartAmount,setCartItem,products}=useContext(StoreContext)
  const [items,setItems]=useState({});

  useEffect(()=>{
 const storedItem=localStorage.getItem("cart");
 if(storedItem){
  setCartItem(JSON.parse(storedItem))
 }
  },[]);

  const addToCart = async ()=>{
   
   const items = localStorage.getItem("cart");
   const parse = items ? JSON.parse(items):{};
   const model = Object.entries(parse).map(([id,quantity])=>({
      productId:id,
       quantity:quantity,
       unitPrice:0
   }));
   
    const responnse = await addCartItem(model);
    console.log(responnse)
    if(responnse.isSuccess){
      if(responnse.statusCode == 200){
        console.log("hy my name is arif")
        navigate("/food-app/placeOrder")
      }
      else{
        console.log("hello mr hoe are you")
      }
      // else if(responnse.statusCode == 401){
      //   console.log("hy my name is arif tantray")
      // setShowLogin(true)
      // }

    }
  }

  return (
    <div className='cart'>
      <div className='cart-items'>
        <div className='cart-items-title'>
          <p>Items</p>
          <p>Title</p>
          <p>Price</p>
          <p>Quantity</p>
          <p>Total</p>
          <p>Remove</p>
        </div>
        <br />
        <hr />
        {
          products && products.map((item,index)=>{
            if(cartItem[item.id]>0){
              return(
                <div>
                     <div className='cart-items-title cart-items-item'>
                  <img src={Base_url+item.files} alt="" />
                  <p>{item.name}</p>
                  <p>${item.price}</p>
                  <p>{cartItem[item.id]}</p>
                  <p>${item.price*cartItem[item.id]}</p>
                  <p onClick={()=>removeFromCart(item.id)} className='cross'>X</p>
                </div>
                <hr />
                </div>
               
              )
            }
          })
        }
      </div>
      <div className='cart-bottom'>
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
              <p>${getTotalCartAmount()===0?0:getTotalCartAmount()===0?0:2}</p>
            </div>
            <hr />
            <div className="cart-total-details">
              <b>Total</b>
              <b>${getTotalCartAmount()===0?0:getTotalCartAmount()+2}</b>
            </div>
          </div>
          <button onClick={()=>addToCart()}>Proceed to checkout</button>
        </div>
        <div className='cart-promocode'>
          <div>
            <p>if you have a promo code, Enter it here</p>
            <div className='cart-promocode-input'>
              <input type="text" placeholder='promo code'/>
              <button>Submit</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Cart
