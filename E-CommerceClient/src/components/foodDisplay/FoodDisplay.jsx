import React, { useContext, useEffect, useState } from 'react'
import "./foodDisplay.css"
import { StoreContext } from '../../context/StoreContext'
import Fooditem from '../FoodItem/Fooditem'
import { getProducts } from '../../service/products/productServices'
const FoodDisplay = ({category}) => {
    const {food_list}=useContext(StoreContext)
    const [products,setProducts]=useState([])

    const fetchingProducts = async () =>{
      const response = await getProducts();
      if (response.isSuccess){
        setProducts(response.value);
      }
    }

    useEffect(()=>{
      fetchingProducts();
    },[])

   
    
  return (
    <div className='food-display' id='food-display'>
      <h2 >Top dishes near you</h2>
      <div className='food-display-list'>
        {products && products.map((item,index)=>{
          if(category==="All" || category===item.category){
            return   <Fooditem key={index} id={item.id} name={item.name} description={item.description} price={item.price} image={item.files} />
          }
         
})}
      </div>
    </div>
  )
}

export default FoodDisplay
