import React from 'react'
import "./appDownload.css"
import { assets } from '../../assets/frontendassets/frontend_assets/assets'
const AppDownload = () => {
  return (
    <div className='app-download' id='app-download'>
      <p>For Better Experience Download <br />Tamato App</p>
      <div className='app-download-plateforms'>
        <img src={assets.play_store} alt="" />
        <img src={assets.app_store} alt="" />
      </div>
    </div>
  )
}

export default AppDownload
