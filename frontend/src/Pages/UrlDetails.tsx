import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { apiUrlAnalytics, UrlAnalyticsDto } from "../api/apiUrlAnalytics";
import { handleApiError } from "../api/apiClient";
import { motion } from "framer-motion";
import { Loader2, ClipboardCheck, Clipboard } from "lucide-react";
//TODO: fix the mmob  view of things

export const UrlDetails = () => {
  const { urlCode } = useParams();
  const [urlInfo, setUrlInfo] = useState<UrlAnalyticsDto | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function getUrlData() {
      if (!urlCode) return;
      try {
        const response = await apiUrlAnalytics(urlCode);

        setUrlInfo(response);
      } catch (error) {
        handleApiError(error);
        setUrlInfo(null);
      } finally {
        setLoading(false);

      }
    }

    getUrlData();
  }, [urlCode]);

  const [copied, setCopied] = useState(false);
  const shortUrl = "www.google.com"
  const handleCopy = () => {
    navigator.clipboard.writeText(shortUrl);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000); // Reset copy message
  };



  if (loading) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <Loader2 className="animate-spin w-8 h-8 text-primary" />
      </div>
    );
  }

  if (!urlInfo) {
    return (
      <div className="text-center text-red-600 mt-10">
        Failed to fetch URL data. Please try again later.
      </div>
    );
  }
  console.log(urlInfo.originalUrl)
  return (

    <div className="max-w-4xl mx-auto px-4 py-2">

<div className="card bg-base-100 shadow-lg border border-neutral p-2 w-1/2 mx-auto">
        <div className="card-body space-y-3">
          <div className="flex items-center justify-between bg-neutral/60 rounded-lg px-4 py-3">
            <a
              href={urlInfo.shortenedUrl}
              target="_blank"
              rel="noopener noreferrer"
              className="text-blue-600 underline truncate "
            >
              {urlInfo.shortenedUrl}
            </a>
           

            <button
              onClick={handleCopy}
              className="btn btn-sm btn-outline btn-primary ml-4"
            >
              {copied ? <ClipboardCheck/> : <Clipboard/>}
            </button>
          </div>
        </div>
      </div>

      <motion.div
        initial={{ opacity: 0, y: 40 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.6 }}
        className="card bg-base-100 shadow-xl border border-base-200 p-6 mt-4"
      >
        <h2 className="text-2xl font-semibold mb-2 text-primary-content">
          URL Analytics
        </h2>
        <p className="text-sm text-gray-500 mb-4">Generated on: {new Date(urlInfo.createdAt).toLocaleString()}</p>

        <div className="space-y-2">
          <p>
            <span className="font-medium">Original URL:</span>
            <div className="overflow-x-auto">
              <a
                href={urlInfo.originalUrl}
                target="_blank"
                rel="noopener noreferrer"
                className="text-blue-600 underline break-all inline-block whitespace-nowrap"
              >
                {urlInfo.originalUrl}
              </a>
            </div>
          </p>

          <p>
            <span className="font-medium">url code:</span> <a href={urlInfo.shortenedCode} target="_blank" className="text-blue-600 underline">{urlInfo.shortenedCode}</a>
          </p>
          <p>
            <span className="font-medium">Click Count:</span> {urlInfo.clickCount}
          </p>
          {urlInfo.expiresAt && (
            <p>
              <span className="font-medium">Expires At:</span> {new Date(urlInfo.expiresAt).toLocaleString()}
            </p>
          )}
        </div>

        <hr className="my-6" />

        <h3 className="text-lg font-semibold mb-3">Click History</h3>
        {(urlInfo.clicks ?? []).length === 0 ? (
          <p className="text-sm text-gray-500 italic">No clicks recorded yet.</p>
        ) : (
          <div className="overflow-x-auto">
            <table className="table table-zebra w-full text-sm">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Country</th>
                  <th>City</th>
                  <th>Device</th>
                  <th>Browser</th>
                  <th>OS</th>
                  <th>IP</th>
                  <th>Bot</th>
                </tr>
              </thead>
              <tbody>
                {(urlInfo.clicks ?? []).map((click, index) => (
                  <tr key={index}>
                    <td>{new Date(click.clickedAt).toLocaleString()}</td>
                    <td>
                      {click.country ? (
                        <span className="flex items-center gap-1">
                          <img
                            src={`https://flagcdn.com/16x12/${click.country.toLowerCase()}.png`}
                            alt={click.country}
                            className="inline w-4 h-3 rounded-sm"
                          />
                          {click.country}
                        </span>
                      ) : (
                        "-"
                      )}
                    </td>
                    <td>{click.city || "-"}</td>
                    <td>{click.deviceType || "-"}</td>
                    <td>{click.browserName || "-"}</td>
                    <td>{click.operatingSystem || "-"}</td>
                    <td>{click.ipAddress || "-"}</td>
                    <td>{click.isBot ? "Yes" : "No"}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </motion.div>
    </div>
  );
};
