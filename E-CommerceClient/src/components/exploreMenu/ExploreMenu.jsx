import React, { useEffect,useState } from 'react'
import "./exploremenu.css"
import { menu_list } from '../../assets/frontendassets/frontend_assets/assets'
import { getCategories } from '../../service/categoryServices/categoryService';
import { CgLaptop } from 'react-icons/cg';
import { Base_url } from '../../constents/appUrls';
const ExploreMenu = ({category,setCategory}) => {
  const [data,setData] = useState();

  const fetchingCategories = async ()=>{
     const response = await getCategories();
     if(response.isSuccess){
      alert(response.message);
      setData(response.value)
     }
  }

  useEffect(()=>{
    fetchingCategories();
  },[])

  return (
    <div className='explore-menu' id='explore-menu'>
      <h1>Explore our menu</h1>
      <p className='explore-menu-text'>Choose from a diverse menu featuring a delectable array of dishes.our mission is to satisfy your cravings and elevate your diningexperience.one delicious meal at a time</p>
      <div className='explore-menu-list'>
        {
           data && data.map((item,index)=>(
                <div onClick={()=>setCategory(prev=>prev===item.name?"All":item.name)} key={index} className='explore-menu-list-item'>
                    <img className={category===item.name?"active":""} src={Base_url+item.filePath} alt="" />
                    <p>{item.name}</p>
                </div>

            ))
        }
      </div>
      <hr />
    </div>
  )
}

export default ExploreMenu
