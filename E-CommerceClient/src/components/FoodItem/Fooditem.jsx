import React, { useContext} from 'react'
import "./fooditem.css"
import { assets } from '../../assets/frontendassets/frontend_assets/assets'
import { StoreContext } from '../../context/StoreContext'
import { ToastContainer, toast } from 'react-toastify';
import { Base_url } from '../../constents/appUrls';



const Fooditem = ({id,name,price,description,image}) => {
    
  const Add=()=>{
    toast.success("add successfull")
  }
    const {cartItem,setCartItems,addToCart,removeFromCart}=useContext(StoreContext)
  return (
    <div className='food-item'>
      <div className='food-item-img-container'>
        <img className='food-item-img' src={Base_url+image} alt="" />
        {
        !cartItem[id] ?<img className='add' onClick={()=>addToCart(id)} src={assets.add_icon_white} alt="" />
        :
        <div className='food-item-counter'>
            <img onClick={()=>removeFromCart(id)}  src={assets.remove_icon_red} alt="" />
            <p>{cartItem[id]}</p>
            <img onClick={()=>{addToCart(id)}} src={assets.add_icon_green} alt="" />
        </div>

        }
      </div>
      <div className='food-item-info'>
        <div className='food-item-name-rating'>
            <p>{name}</p>
            <img src={assets.rating_starts} alt="" />
        </div>
        <p className='food-item-description'>{description}</p>
        <p className='food-item-price'>${price}</p>
      </div>
      
      <ToastContainer/>
      
      
    </div>
  )
}

export default Fooditem
