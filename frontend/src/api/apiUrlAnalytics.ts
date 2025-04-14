import apiClient, { handleApiError } from "./apiClient";

export interface ClickHistoryDto {

    // with refernce to clickHistorydto.cs
    clickedAt: string; 
    referrer: string | null; 
    ipAddress: string | null; 
    userAgent: string;
    country: string | null; 
    city: string | null; 
    deviceType: string | null; 
    browserName: string | null; 
    operatingSystem: string | null; 
    isBot: boolean | null; 
  }
  

 export  interface UrlAnalyticsDto {
    originalUrl: string;
    shortenedCode: string;
    shortenedUrl: string;
    clickCount: number;
    createdAt: string;
    expiresAt?: string;
    clicks: ClickHistoryDto[];
  }
  


export const apiUrlAnalytics = async (urlCode:string): Promise<UrlAnalyticsDto | null> => {

    const getUrl = `/api/Url/${urlCode}/details`;
    try {
        const response = await apiClient.get<UrlAnalyticsDto>(getUrl);
        return response.data;
    } catch (error) {
        console.log(`Error fecthing data for ${urlCode}`);
        handleApiError(error)
        return null;
    }
    
}