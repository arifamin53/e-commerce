import React, { useContext, useState } from 'react'
import "./navbar.css"
import { assets } from '../../assets/frontendassets/frontend_assets/assets'
import {Link} from "react-router-dom"
import { StoreContext } from '../../context/StoreContext'
const Navbar = ({setShowLogin}) => {
  const {getTotalCartAmount}=useContext(StoreContext)
    const [menu,setMenu]=useState("home")
  return (
    <div className='navbar'>
    <Link to="/food-app/"><img src={assets.logo} alt="" className='logo'/></Link>  
      <ul className='navbar-manu'>
     <Link to="/" onClick={()=>setMenu("home")} className={menu==="home"?"active":""}>Home</Link>
        <a href='#explore-menu' onClick={()=>setMenu("menu")} className={menu==="menu"?"active":""}>Menu</a>
        <a href='#app-download' onClick={()=>setMenu("mobile-app")} className={menu==="mobile-app"?"active":""}>Mobile App</a>
        <a href='#footer' onClick={()=>setMenu("contact-us")} className={menu==="contact-us"?"active":""}>Contactus</a>
      </ul>
      <div className='navbar-right'>
        <img className='search-icon' src={assets.search_icon} alt="" />
        <div className='navbar-search-icon'>
          
           <Link to="/food-app/cart"><img src={assets.basket_icon} alt="" /></Link> 
            <div className={getTotalCartAmount()===0?"":"dot"}></div>
        </div>
        <button onClick={()=>setShowLogin(true)}>SignIn</button>
      </div>
    </div>
  )
}

export default Navbar
