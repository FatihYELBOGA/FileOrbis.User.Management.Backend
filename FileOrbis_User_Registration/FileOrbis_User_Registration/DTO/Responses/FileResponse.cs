using FileOrbis_User_Registration.Models;

namespace FileOrbis_User_Registration.DTO.Responses
{
    public class FileResponse
    {
        public FileResponse(Models.File file) 
        {
            Id = file.Id;
            Name = file.Name;
            Type = file.Type;   
            Content = file.Content;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }

    }

}
