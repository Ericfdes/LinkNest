
import { Button, Hero } from 'react-daisyui';
import { UrlInput } from './UrlInput';


export  const HeroComponent = () => {
  return (
    <Hero>
    <Hero.Content className="text-center">
      <div className="max-w-md">
        <h1 className="text-5xl font-bold">Hello there</h1>
        <UrlInput/>
        
      </div>
    </Hero.Content>
  </Hero>
  )
}
