import React, { useState } from 'react'
import "./home.css"
import Header from '../../components/header/Header'
import ExploreMenu from '../../components/exploreMenu/ExploreMenu'
import FoodDisplay from '../../components/foodDisplay/FoodDisplay'
import AppDownload from '../../components/appDownload/AppDownload'
import Navbar from '../../components/Navbar/Navbar'
import Footer from '../../components/footer/Footer'
import LoginPOPup from '../../components/loginPopup/LoginPOPup'
// import Navbar from './components/Navbar/Navbar'

const Home = () => {
  const [category, setCategory] = useState("All")
  const [showLogin, setShowLogin] = useState(false)
  return (
    <>
    <div>
      {
        showLogin ? <LoginPOPup setShowLogin={setShowLogin} /> : <></>
      }
      <Navbar setShowLogin={setShowLogin} />
      <Header />
      <ExploreMenu category={category} setCategory={setCategory} />
      <FoodDisplay category={category} />
      <AppDownload /> 
    </div>
    <div>
      <Footer />
    </div> 
    </>
  )
}

export default Home

