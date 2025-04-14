import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";

type Props = {
  originalUrl: string;
  shortUrl: string;
  shortCode : string
};

export const GeneratedUrlCard = ({ originalUrl, shortUrl,shortCode }: Props) => {
  const [copied, setCopied] = useState(false);
  const navigate = useNavigate();
  const handleCopy = () => {
    navigator.clipboard.writeText(shortUrl);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000); // Reset copy message
  };

  return (
    <div

      className="max-w-xl mx-auto mt-8"
    >
      <div className="card bg-base-100 shadow-lg border border-neutral p-6">
        <div className="card-body space-y-3">
          <h2 className="card-title text-primary text-lg">
            🎉 Your URL is ready!
          </h2>

          <div className="flex items-center justify-between bg-neutral/10 rounded-lg px-4 py-3">
            <a
              href={shortUrl}
              target="_blank"
              rel="noopener noreferrer"
              className="text-blue-600 underline truncate"
            >
              {shortUrl}
            </a>

            <button
              onClick={handleCopy}
              className="btn btn-sm btn-outline btn-primary ml-4"
            >
              {copied ? "Copied!" : "Copy"}
            </button>
          </div>

          <div>
            Original:
          </div>
          <div className="w-full overflow-x-auto bg-neutral/10 rounded-md px-4 py-2">

            <span className="whitespace-nowrap font-medium text-gray-700">
              {originalUrl}
            </span>
          </div>


          <div className="text-xs text-right text-gray-400 italic">
            Generated just now
          </div>

          <button className="btn btn-neutral btn-md" onClick={()=>(navigate(`url/${shortCode}/details`))}>
              View Info
          </button>

        </div>
      </div>
    </div>
  );
};
