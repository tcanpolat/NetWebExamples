import { useState } from 'react'
import './App.css'
import axios from 'axios'
import { useEffect } from 'react'
function App() {
  const [count, setCount] = useState(0)
  const[products,setProducts] = useState([])
  const[errorHandle, setErrorHandle] = useState(false)
  useEffect(()=>{
    axios.get("https://localhost:7268/api/Product/GetProducts")
    .then((res)=>{
      console.log(res)
      if(res.status == 200){
        setProducts(res.data)
      }
    })
    .catch((e)=>{
      if(e.response.data.status == 404){
        setErrorHandle(true)
      }
      console.log(e);
    })
  },[])
  return (
    <>
      {errorHandle ? "Bir Hata Oluştu!":
        products.map((product,key) => 
          <div key={key}>
              <h3>{product.title}</h3>
              <p>{product.description}</p>
              <p>{product.price}</p>
          </div>
        )
      }
    </>
  )
}

export default App
