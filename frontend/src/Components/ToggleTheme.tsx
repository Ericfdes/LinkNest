import React, { useEffect, useState } from 'react';
import { Toggle } from 'react-daisyui';

export const ToggleTheme = () => {
  const [theme, setTheme] = useState('black');

  useEffect(() => {
    document.querySelector('html')?.setAttribute('data-theme', theme);
  }, [theme]);

  const toggleTheme = () => {
    setTheme(prev => (prev === 'light' ? 'black' : 'light'));
  };

  return (
    <div className="p-4">
      <Toggle onChange={toggleTheme} size='sm' checked={theme === 'light'} />
    </div>
  );
};
