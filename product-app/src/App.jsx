import { useState } from 'react'
import './App.css'
import axios from 'axios'
import { useEffect } from 'react'
function App() {
  const [count, setCount] = useState(0)
  useEffect(()=>{
    axios.get("https://localhost:7268/api/Product/GetProducts")
    .then((res)=>{
      console.log(res)
    })
    .catch((e)=>{
      console.log(e);
    })
  },[])
  return (
    <>
     
    </>
  )
}

export default App
