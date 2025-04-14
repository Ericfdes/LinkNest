import { Button, Menu, Navbar } from "react-daisyui"
import { ToggleTheme } from "./ToggleTheme"

function TopNav() {
  return (
    <Navbar  className="rounded-box shadow-md bg-base-200  flex flex-row items-center justify-around ">
    <div className="flex-1">
      <Button tag="a" color="ghost" className="normal-case text-xl">
        LinkNest
      </Button>
    </div>
    <div className="flex items-center">
      <Menu horizontal={true} className="px-1">
        <Menu.Item className="flex items-center justify-center">
          <a>Link</a>
        </Menu.Item>
        <Menu.Item className="flex items-center justify-center">
        <a>Github</a>
        </Menu.Item>
        <Menu.Item>
           <ToggleTheme/>
        </Menu.Item>
      </Menu>
    </div>
  </Navbar>
  )
}

export default TopNav