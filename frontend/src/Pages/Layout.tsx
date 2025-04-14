import TopNav from "../Components/TopNav"
import { NavLink, Outlet } from "react-router-dom";

export const Layout = () => {
  return (
    <>
        <TopNav/>
        <div className="mt-7">
            <Outlet/>
        </div>
        
    </>
  )
}
