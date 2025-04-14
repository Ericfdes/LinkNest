import apiClient from "./apiClient";
import { handleApiError } from "./apiClient";

export interface ShortUrlResponse{
    //according to ShortUrlResponseDto.cs 
    shortCode : string,
    shortUrl : string,
}

export const apiShortenUrl = async (OriginalUrl : string) : Promise<ShortUrlResponse | null> =>{
    try {
        console.log({OriginalUrl})
        const response = await apiClient.post<ShortUrlResponse>(`api/url/shorten`,{OriginalUrl});
        return response.data;
        
    } catch (error) {
        handleApiError(error);
        return null;
        
    }
    
}
