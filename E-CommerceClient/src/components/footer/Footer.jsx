import React from 'react'
import "./footer.css"
import { assets } from '../../assets/frontendassets/frontend_assets/assets'
const Footer = () => {
  return (
    <div className='footer' id='footer'> 
      <div className='footer-content'>
        <div className='footer-content-left'>
            <img src={assets.logo} alt="" />
            <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Doloremque obcaecati laudantium quos neque similique dolores doloribus cumque deleniti suscipit itaque.</p>
            <div className='footer-social-icons'>
                <img src={assets.facebook_icon} alt="" />
                <img src={assets.twitter_icon} alt="" />
                <img src={assets.linkedin_icon} alt="" />
            </div>
        </div>
        <div className='footer-content-center'>
            <h2>Company</h2>
            <ul>
                <li>Home</li>
                <li>About us</li>
                <li>Delivery</li>
                <li>Privacy policy</li>
            </ul>
        </div>
        <div className='footer-content-right'>
            <h2>Get In Touch</h2>
            <ul>
                <li>+91 7889424853</li>
                <li>arifamin123@gmail.com</li>
            </ul>
        </div>
        
      </div>
      <hr />
      <p className='footer-copyright'>Copyright 2025 @ Tamato.com - All Right Reserved.</p>
    </div>
  )
}

export default Footer
