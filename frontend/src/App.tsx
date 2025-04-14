import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import { Home } from "./Pages/Home";
import { Layout } from "./Pages/Layout";
import { UrlDetails } from "./Pages/UrlDetails";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="/url/:urlCode/details" element={<UrlDetails />} />
        </Route> {/* end of layout route element */}
      </Routes>
    </Router>
  );
}

export default App;
