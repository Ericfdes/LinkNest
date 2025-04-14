import { useState } from "react";
import { apiShortenUrl } from "../api/apiShortenUrl";
import { GeneratedUrlCard } from "./GeneratedUrlCard";
import { AnimatePresence, motion } from "framer-motion"; // 
import { ShortUrlResponse } from "../api/apiShortenUrl";

export const UrlInput = () => {
  const [url, setUrl] = useState("");
  const [isValid, setIsValid] = useState(true);
  //const [shortUrl, setShortUrl] = useState<ShortUrlResponse | null>({shortCode: "abcHig",shortUrl:"wwww.example.com/;"}); //for testing
  const [shortUrl, setShortUrl] = useState<ShortUrlResponse | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setUrl(value);
    const pattern = /^(https?:\/\/)?([\w\-]+\.)+[\w\-]{2,}(\/\S*)?$/;
    setIsValid(pattern.test(value));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!isValid || !url) return;
    const response = await apiShortenUrl(url);
    if (response && response.shortUrl) {
      setShortUrl(response);
      setTimeout(() => {
        document.getElementById("result-card")?.scrollIntoView({ behavior: "smooth" });
      }, 100);
    }
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen px-4 py-8 space-y-6">
      <form
        onSubmit={handleSubmit}
        className="flex flex-col items-center justify-center space-y-4 w-full"
      >
        <input
          placeholder="Enter your URL..."
          className={`input input-bordered input-lg w-full max-w-xl ${
            !isValid ? "input-error" : ""
          }`}
          value={url}
          onChange={handleChange}
          required
        />
        {!isValid && (
          <span className="text-error text-sm -mt-3">
            Please enter a valid URL (e.g., https://example.com)
          </span>
        )}

        <button type="submit" className="btn btn-primary w-full max-w-xl">
          Shorten URL
        </button>
      </form>

      <AnimatePresence mode="wait">
        {shortUrl && (
          <motion.div
            key="generated-card"
            id="result-card"
            initial={{ opacity: 0, y: 50 }}
            animate={{ opacity: 1, y: 0 }}
            exit={{ opacity: 0, y: 50 }}
            transition={{ duration: 0.5, ease: "easeOut" }}
            className="w-full px-4"
          >
            <GeneratedUrlCard originalUrl={url} shortUrl={shortUrl.shortUrl} shortCode={shortUrl.shortCode} />
          </motion.div>
        )}
      </AnimatePresence>
    </div>
  );
};
