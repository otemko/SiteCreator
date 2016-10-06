import { SearchTag } from './searchTag.model'
import { SearchUser } from './searchUser.model'
import { SearchSite } from './searchSite.model'


export class SearchResult {
    searchSites: SearchSite[]
    searchTags: SearchTag[];
    searchUsers: SearchUser[];
}