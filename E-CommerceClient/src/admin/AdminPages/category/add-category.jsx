import React from 'react'
import '../../../components/CommonForm_css/form.css'
import { useForm } from 'react-hook-form'
import { categoryAdd } from '../../../service/categoryServices/categoryService'
import { toast } from 'react-toastify'

const AddCategory = () => {
 const {register,handleSubmit,formState:{errors}} = useForm()

 const submit = async (model)=>{
    const formData = new FormData();
    formData.append('name',model.name);
    formData.append('description',model.description);
    formData.append('file',model.file[0])
    var response = await categoryAdd(formData);
    if(response?.isSuccess){
        toast.success(response.message)
    }
    toast.error(response.message)
 }

  return (
    <div className='form-page'>
        <div className='form-container'>

        <h1 className='form-title'>AddCategory</h1>
      <form className='common-form' onSubmit={handleSubmit(submit)}>
        <div className='form-group'>
            <label htmlFor="">Name</label>
            <input type="text" id='name' {...register("name")}/>
        </div>
         <div className='form-group'>
            <label htmlFor="">Description</label>
            <input type="text" id='description'{...register("description")} />
        </div>
         <div className='form-group'>
            <label htmlFor="">File</label>
            <input type="file" id='file' {...register("file")}/>
        </div>
        <button type="submit" className="form-btn">Submit</button>
      </form>
      
    </div>
     </div>
  )
}

export default AddCategory
